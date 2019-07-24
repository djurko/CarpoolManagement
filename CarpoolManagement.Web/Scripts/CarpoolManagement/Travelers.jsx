class Travelers extends React.Component {
    render() {
        if (this.props.currentStep !== 2 || !this.props.list) {
            return null;
        }
        const travelers = this.props.list.map(element => (
            <p key={element.Id}><button id={element.Id} type="button" className="btn-primary" onClick={this.props.removeEmployeeFromTravelPlan}>-</button><a href={'/Employees/Details/' + element.Id} style={{ marginLeft: 10 }}>{element.Name}</a></p>
        ));
        return (
            <div>{travelers}</div>
        );
    }
}

export default Travelers;