import React from 'react';
import { Categories } from '../../stringLiterals/category-names.js';
import moment from 'moment';

export default class ExpenseCard extends React.PureComponent {
    render() {
        const expense = this.props.expense;
        const format = "DD-MM-YYYY HH:mm"
        return(
            <div className="card bg-dark mb-2">
                <div className="card-body text-primary">
                    <div className="row">
                        <div className="col-2 text-right">
                            <h4><span className={`fa ${Categories.find(c => c.name.toLowerCase() === expense.category.toLowerCase()).fa}`}></span></h4>
                        </div>
                        <div className="col-10 text-left">
                            <h4><span className="badge badge-primary">{expense.category}</span></h4>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-2 text-right">
                            <h4 className="align-content-center mr-1"><span className="fa fa-dollar-sign"></span></h4>
                        </div>
                        <div className="col-10 text-left">
                            <h4><span className="badge badge-primary">{expense.cost} PLN</span></h4>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-2 text-right">
                            <h4 className="align-content-center"><span className="fa fa-clock"></span></h4>
                        </div>
                        <div className="col-10 text-left">
                            <h4><span className="badge badge-primary">{moment(expense.dateCreated).format(format)}</span></h4>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}