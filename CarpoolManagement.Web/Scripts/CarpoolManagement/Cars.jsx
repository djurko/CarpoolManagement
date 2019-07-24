class Cars extends React.Component {
    render() {
        if (this.props.currentStep !== 2 || !this.props.list) {
            return null;
        }
        const car = this.props.list;
        return (
            <div>
                <p key={car.Id}><button id={car.Id} type="button" className="btn-primary" onClick={this.props.removeCarFromTravelPlan}>-</button><a href={'/Carpools/Details/' + car.Id} style={{ marginLeft: 10 }}>{car.Name}</a></p>
            </div>
        );
    }
}

export default Cars;