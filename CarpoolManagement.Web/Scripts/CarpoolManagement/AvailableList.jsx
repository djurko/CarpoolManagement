class AvailableList extends React.Component {
    render() {
        if (this.props.currentStep !== 2 || !this.props.list) {
            return null;
        }
        const elements = this.props.list.map(element => (
            <p key={element.Id}><button id={element.Id} type="button" className="btn-primary" onClick={this.props.mode === "cars" ? this.props.addCarToTravelPlan : this.props.addEmployeeToTravelPlan}>+</button><a href={(this.props.mode === "cars" ? '/Carpools/Details/' : '/Employees/Details/') + element.Id} style={{ marginLeft: 10 }}>{element.Name}</a></p>
        ));
        return (
            <div>{elements}</div>
        );
    }
}

export default AvailableList;