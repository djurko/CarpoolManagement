import Step1 from "./Step1.jsx";
import Step2 from "./Step2.jsx";

class Form extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            currentStep: 1,
            startLocation: '',
            endLocation: '',
            startDate: '',
            endDate: ''
        };
        this.handleChange = this.handleChange.bind(this);
        this.addEmployeeToTravelPlan = this.addEmployeeToTravelPlan.bind(this);
        this.removeEmployeeFromTravelPlan = this.removeEmployeeFromTravelPlan.bind(this);
        this.addCarToTravelPlan = this.addCarToTravelPlan.bind(this);
        this.removeCarFromTravelPlan = this.removeCarFromTravelPlan.bind(this);
        this._next = this._next.bind(this);
        this._prev = this._prev.bind(this);
    }
    _next() {
        let currentStep = this.state.currentStep;
        // If the current step is 1, then add one on "next" button click
        currentStep = currentStep === 1 ? currentStep + 1 : 2;
        this.setState({
            currentStep: currentStep
        });
        this.handleNext(this.state);
    }
    _prev() {
        let currentStep = this.state.currentStep;
        // If the current step is 2, then subtract one on "previous" button click
        currentStep = currentStep === 2 ? currentStep - 1 : 1;
        this.setState({
            currentStep: currentStep
        });
    }
    get previousButton() {
        let currentStep = this.state.currentStep;
        // If the current step is not 1, then render the "previous" button
        if (currentStep > 1) {
            return (
                <div className="form-group">
                    <div className="col-md-offset-2 col-md-10">
                        <button className="btn btn-secondary" type="button" onClick={this._prev}>Previous</button>
                        <button className="btn btn-primary" type="button" onClick={this.handleSubmit} style={{marginLeft: 10}}>Submit</button>
                    </div>
                </div>
            );
        }
        // ...else return nothing
        return null;
    }
    get nextButton() {
        let currentStep = this.state.currentStep;
        // If the current step is not 2, then render the "next" button
        if (currentStep < 2) {
            return (
                <div className="form-group">
                    <div className="col-md-offset-2 col-md-10">
                        <button disabled={!this.state.startLocation || !this.state.endLocation || !this.state.startDate || !this.state.endDate} className="btn btn-primary" type="button" onClick={this._next}>Next</button>
                    </div>
                </div>
            );
        }
        // ...else render nothing
        return null;
    }
    handleChange(event) {
        const { name, value } = event.target;
        this.setState({
            [name]: value
        });
    }
    addEmployeeToTravelPlan(event) {
        const { id } = event.target;

        //new list for AvailableEmployees
        var newAvailableEmployees = this.state.data.availableEmployees.filter(function(element) {
            return element.Id !== parseInt(id);
        });

        //new list for EmployeesOnTravel
        var newEmployeesOnTravel = [];
        if (this.state.data.travelPlan.EmployeeTravelPlans !== null) {
            newEmployeesOnTravel = this.state.data.travelPlan.EmployeeTravelPlans;
        }
        newEmployeesOnTravel.push(this.state.data.availableEmployees.find(obj => obj.Id === parseInt(id)));

        //HasDriver
        var hasDriver = false;
        if (newEmployeesOnTravel.find(obj => obj.IsDriver)) {
            hasDriver = true;
        }

        this.setState(prevState => ({
            data: {
                ...prevState.data,
                availableEmployees: newAvailableEmployees,
                travelPlan: {
                    ...prevState.data.travelPlan,
                    EmployeeTravelPlans: newEmployeesOnTravel,
                    HasDriver: hasDriver
                }
            }
        }));
    }
    removeEmployeeFromTravelPlan(event) {
        const { id } = event.target;

        //new list for AvailableEmployees
        var employee = this.state.data.travelPlan.EmployeeTravelPlans.find(obj => obj.Id === parseInt(id));
        var newAvailableEmployees = this.state.data.availableEmployees;
        newAvailableEmployees.push(employee);

        //new list for EmployeesOnTravel
        var newEmployeesOnTravel = this.state.data.travelPlan.EmployeeTravelPlans.filter(function (element) {
            return element.Id !== parseInt(id);
        });

        //HasDriver
        var hasDriver = false;
        if (newEmployeesOnTravel.find(obj => obj.IsDriver)) {
            hasDriver = true;
        }

        this.setState(prevState => ({
            data: {
                ...prevState.data,
                availableEmployees: newAvailableEmployees,
                travelPlan: {
                    ...prevState.data.travelPlan,
                    EmployeeTravelPlans: newEmployeesOnTravel,
                    HasDriver: hasDriver
                }
            }
        }));
    }
    addCarToTravelPlan(event) {
        const { id } = event.target;

        //new list for AvailableCars
        var newAvailableCars = this.state.data.availableCarpools.filter(function (element) {
            return element.Id !== parseInt(id);
        });
        if (this.state.data.travelPlan.Car !== null) {
            newAvailableCars.push(this.state.data.travelPlan.Car);
        }

        //Car used for travel
        var car = this.state.data.availableCarpools.find(obj => obj.Id === parseInt(id));

        this.setState(prevState => ({
            data: {
                ...prevState.data,
                availableCarpools: newAvailableCars,
                travelPlan: {
                    ...prevState.data.travelPlan,
                    Car: car,
                    CarId: car.Id
                }
            }
        }));
    }
    removeCarFromTravelPlan(event) {
        const { id } = event.target;

        //new list for AvailableCars
        var car = this.state.data.travelPlan.Car;
        var newAvailableCars = this.state.data.availableCarpools;
        newAvailableCars.push(car);

        this.setState(prevState => ({
            data: {
                ...prevState.data,
                availableCarpools: newAvailableCars,
                travelPlan: {
                    ...prevState.data.travelPlan,
                    Car: null,
                    CarId: 0
                }
            }
        }));
    }
    handleNext(state) {
        const params = new FormData();
        params.append('StartLocation', state.startLocation);
        params.append('EndLocation', state.endLocation);
        params.append('StartDate', state.startDate);
        params.append('EndDate', state.endDate);

        const xhr = new XMLHttpRequest();
        //XMLHttpRequest ignorira payload preko GET pa šaljem POST jer mi treba poslat model a ne query string
        xhr.open('post', this.props.nextUrl, true);
        xhr.onload = () => {
            var data = JSON.parse(xhr.responseText);
            data.travelPlan.StartDate = new Date(parseInt(data.travelPlan.StartDate.substr(6))).toLocaleString('en-GB');
            data.travelPlan.EndDate = new Date(parseInt(data.travelPlan.EndDate.substr(6))).toLocaleString('en-GB');
            this.setState({ data: data });
        };
        xhr.send(params);
    }
    handleSubmit = (event) => {
        event.preventDefault();
        //console.log(this.state);
        const { travelPlan } = this.state.data;
        travelPlan.EmployeeIds = travelPlan.EmployeeTravelPlans.map(e => e.Id);
        const params = JSON.stringify(travelPlan);
        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
        xhr.onload = () => {
            var data = JSON.parse(xhr.responseText);
            if (data.success === true) {
                window.location.href = "/TravelPlans";
            }
        }
        xhr.send(params);
    }
    render() {
        if (this.state.data) {
            //console.log(this.state.data);
        }
        return (
            <form onSubmit={this.handleSubmit}>
                <Step1
                    currentStep={this.state.currentStep}
                    startLocation={this.state.startLocation}
                    endLocation={this.state.endLocation}
                    startDate={this.state.startDate}
                    endDate={this.state.endDate}
                    handleChange={this.handleChange}
                />
                <Step2
                    currentStep={this.state.currentStep}
                    data={this.state.data}
                    addEmployeeToTravelPlan={this.addEmployeeToTravelPlan}
                    addCarToTravelPlan={this.addCarToTravelPlan}
                    removeEmployeeFromTravelPlan={this.removeEmployeeFromTravelPlan}
                    removeCarFromTravelPlan={this.removeCarFromTravelPlan}
                />
                <div className="form-horizontal">
                    {this.previousButton}
                    {this.nextButton}
                </div>
            </form>
        );
    }
}

ReactDOM.render(
    <Form
        nextUrl="/TravelPlans/FindAvailableEmployeesAndCars"
        submitUrl="/TravelPlans/Create"
    />,
    document.getElementById('Form')
);