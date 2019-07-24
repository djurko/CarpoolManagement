import AvailableList from "./AvailableList.jsx";
import Travelers from "./Travelers.jsx";
import Cars from "./Cars.jsx";

class Step2 extends React.Component {
    render() {
        if (this.props.currentStep !== 2 || !this.props.data) {
            return null;
        }
        return (
            <div>
                <h4>Travel Plan</h4>
                <hr />
                <div className="col-md-4">
                    <h4>Available Employees ({this.props.data.availableEmployees ? this.props.data.availableEmployees.length : 0})</h4>
                    <AvailableList
                        mode="employees"
                        list={this.props.data.availableEmployees}
                        currentStep={this.props.currentStep}
                        addEmployeeToTravelPlan={this.props.addEmployeeToTravelPlan}
                    />
                </div>
                <div className="col-md-4">
                    <h4>Travel Plan</h4>
                    <dl>
                        <dt className="col-md-6">Start Location</dt>
                        <dd className="col-md-6">{this.props.data.travelPlan.StartLocation}</dd>
                        <dt className="col-md-6">End Location</dt>
                        <dd className="col-md-6">{this.props.data.travelPlan.EndLocation}</dd>
                        <dt className="col-md-6">Start Date</dt>
                        <dd className="col-md-6">{this.props.data.travelPlan.StartDate}</dd>
                        <dt className="col-md-6">End Date</dt>
                        <dd className="col-md-6" style={{marginBottom: 20}}>{this.props.data.travelPlan.EndDate}</dd>
                    </dl>
                    <h4>Employees ({this.props.data.travelPlan.EmployeeTravelPlans ? this.props.data.travelPlan.EmployeeTravelPlans.length : 0})</h4>
                    <Travelers
                        list={this.props.data.travelPlan.EmployeeTravelPlans}
                        currentStep={this.props.currentStep}
                        removeEmployeeFromTravelPlan={this.props.removeEmployeeFromTravelPlan}
                    />
                    <h4>Car (Number of Seats: {this.props.data.travelPlan.Car ? this.props.data.travelPlan.Car.NumberOfSeats : 0})</h4>
                    <Cars
                        list={this.props.data.travelPlan.Car}
                        currentStep={this.props.currentStep}
                        removeCarFromTravelPlan={this.props.removeCarFromTravelPlan}
                    />
                </div>
                <div className="col-md-4">
                    <h4>Available Cars ({this.props.data.availableCarpools ? this.props.data.availableCarpools.length : 0})</h4>
                    <AvailableList
                        mode="cars"
                        list={this.props.data.availableCarpools}
                        currentStep={this.props.currentStep}
                        addCarToTravelPlan={this.props.addCarToTravelPlan}
                    />
                </div>
            </div>
        );
    }
}

export default Step2;