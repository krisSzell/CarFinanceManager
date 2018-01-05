import React from 'react';
import ExpensesList from './expenses-list.jsx';
import AddExpense from './add-expense.jsx';

class Dashboard extends React.PureComponent {
    render() {
        return(
            <div>
                <div className="col-sm-12 col-md-6">
                    <h2 className="text-success">Latest expenses:</h2>
                    <AddExpense {...this.props} />
                    <ExpensesList {...this.props} />
                </div>
            </div>
        )
    }
}

export default Dashboard;