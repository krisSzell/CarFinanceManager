import React from 'react';
import ExpensesService from '../../rest/expenses.service.jsx';
import moment from 'moment';

const apiDateFormat = "YYYY-MM-DDTHH:mm:ss";

export default class AddExpense extends React.PureComponent {

    handleExpenseAdd = event => {
        event.preventDefault();

        this.props.expensesService.add({
            cost: this.cost.value,
            category: this.category.value,
            dateCreated: moment().format(apiDateFormat),
            vehicleId: this.vehicle.value
        })
        .then(res => this.addExpense(res.data));

        var modal = $('#addExpense');
        modal.modal('hide');
        this.resetForm();
    }

    resetForm = () => {
        this.cost.value = null;
        this.category.value = null;
        this.vehicle.value = null;
    }

    addExpense = expense => {
        this.props.onExpenseAdd(expense);
    }

    render() {
        const categories = this.props.categories || [];
        return (
            <div>
                <div className="text-center text-success mb-3">
                    <span 
                        className="fa fa-plus-circle fa-5x expense-add" 
                        data-toggle="modal" 
                        data-target="#addExpense"></span>
                    <p>Add New</p>
                </div>
                <div className="modal fade" id="addExpense" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div className="modal-dialog" role="document">
                      <div className="modal-content">
                        <div className="modal-header">
                          <h5 className="modal-title" id="exampleModalLabel">Add New</h5>
                          <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                          </button>
                        </div>
                        <form onSubmit={this.handleExpenseAdd}>
                            <div className="modal-body">
                                <div className="form-group">
                                    <label htmlFor="cost">Cost:</label>
                                    <input 
                                        type="number" 
                                        className="form-control" 
                                        placeholder="Enter cost" 
                                        ref={input => this.cost = input}
                                        step="10"
                                        min="10"/>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="category">Select Category:</label>
                                    <select name="category" className="form-control" ref={input => this.category = input}>
                                        {categories.map(cat => (
                                            <option key={cat.expenseCategoryId} value={cat.name}>{cat.name}</option>
                                        ))}
                                    </select>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="vehicle">Select Vehicle:</label>
                                    <select name="vehicle" className="form-control" ref={input => this.vehicle = input}>
                                        {this.props.vehicles.map(v => (
                                            <option key={v.id} value={v.id}>{v.make} {v.model}</option>
                                        ))}
                                    </select>
                                </div>
                            </div>
                            <div className="modal-footer">
                              <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                              <button type="submit" className="btn btn-primary">Add</button>
                            </div>
                        </form>
                      </div>
                    </div>
                </div>
            </div>
        );
    }
}