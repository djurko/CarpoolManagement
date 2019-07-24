class Step1 extends React.Component {
    render() {
        if (this.props.currentStep !== 1) {
            return null;
        }
        return (
            <div className="form-horizontal">
                <h4>Travel Plan</h4>
                <hr />
                <div className="form-group">
                    <label className="control-label col-md-2" htmlFor="StartLocation">Start Location</label>
                    <div className="col-md-10">
                        <input className="form-control text-box single-line" data-val="true" data-val-required="The StartLocation field is required." id="StartLocation" name="startLocation" type="text" value={this.props.startLocation} onChange={this.props.handleChange}></input>
                        <span className="field-validation-valid text-danger" data-valmsg-for="StartLocation" data-valmsg-replace="true"></span>
                    </div>
                </div>
                <div className="form-group">
                    <label className="control-label col-md-2" htmlFor="EndLocation">End Location</label>
                    <div className="col-md-10">
                        <input className="form-control text-box single-line" data-val="true" data-val-required="The EndLocation field is required." id="EndLocation" name="endLocation" type="text" value={this.props.endLocation} onChange={this.props.handleChange}></input>
                        <span className="field-validation-valid text-danger" data-valmsg-for="EndLocation" data-valmsg-replace="true"></span>
                    </div>
                </div>
                <div className="form-group">
                    <label className="control-label col-md-2" htmlFor="StartDate">Start Date</label>
                    <div className="col-md-10">
                        <input className="form-control text-box single-line" data-val="true" data-val-date="The field StartDate must be a date." data-val-required="The StartDate field is required." id="StartDate" name="startDate" type="datetime-local" value={this.props.startDate} onChange={this.props.handleChange}></input>
                        <span className="field-validation-valid text-danger" data-valmsg-for="StartDate" data-valmsg-replace="true"></span>
                    </div>
                </div>
                <div className="form-group">
                    <label className="control-label col-md-2" htmlFor="EndDate">End Date</label>
                    <div className="col-md-10">
                        <input className="form-control text-box single-line" data-val="true" data-val-date="The field EndDate must be a date." data-val-required="The EndDate field is required." id="EndDate" name="endDate" type="datetime-local" value={this.props.endDate} onChange={this.props.handleChange}></input>
                        <span className="field-validation-valid text-danger" data-valmsg-for="EndDate" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>
        );
    }
}

export default Step1;