import React from 'react';
import ExpenseCard from './expense-card.jsx';

export default class ExpensesList extends React.PureComponent {
    render() {
        return(
            <div className="expenses-list">
                {this.props.expenses.map(expense => 
                    (
                        <ExpenseCard 
                            key={expense.id} 
                            expense={expense} />
                    ))}
            </div>
        );
    }
}