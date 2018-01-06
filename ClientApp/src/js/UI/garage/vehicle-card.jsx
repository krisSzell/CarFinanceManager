import React from 'react';

export default class VehicleCard extends React.PureComponent {
    calculateExpensesForVehicle = () => {
        var sum = 0;
        this.props.expenses
            .filter(e => e.vehicleId === this.props.id)
            .forEach(v => sum += v.cost);

        return sum;
    }

    render() {
        return(
            <div className="card col-xs-12 col-md-6 bg-primary border-success text-success">
                <div className="card-body">
                    <h4 className="card-title">{this.props.make} {this.props.model}</h4>
                    <p className="card-text text-warning">Total cost: {this.calculateExpensesForVehicle()}</p>
                    <div className="row h5">
                        <div className="col-6 d-flex justify-content-end">
                            Mileage
                        </div>
                        <div className="col-6">
                            <span className="badge badge-success">{this.props.mileage}</span>
                        </div>
                    </div>
                    <div className="row h5">
                        <div className="col-6 d-flex justify-content-end">
                            Production Year
                        </div>
                        <div className="col-6">
                            <span className="badge badge-success">{this.props.productionYear}</span>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}