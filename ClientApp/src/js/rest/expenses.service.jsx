import axios from 'axios';
import { expensesUrl } from '../stringLiterals/api-urls';

export default class ExpensesService {
    constructor(token) {
        this.token = token;
    }

    setToken = token => {
        this.token = token;
    }

    removeToken = () => {
        this.token = null;
    }

    getAll = () => 
        axios({
            method: 'GET',
            url: expensesUrl + '/current', 
            headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${this.token}`,
            }
        });

    add = expense => 
        axios.post(expensesUrl + '/new', expense, {
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${this.token}`
            }
        });
}