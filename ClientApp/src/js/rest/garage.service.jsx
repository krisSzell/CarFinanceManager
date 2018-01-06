import axios from 'axios';
import { garageUrl } from '../stringLiterals/api-urls';

export default class GarageService {
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
            url: garageUrl + '/all', 
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${this.token}`,
            }
        });
}