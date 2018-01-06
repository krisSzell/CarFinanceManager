import axios from 'axios';
import { categoriesUrl } from '../stringLiterals/api-urls';

class CategoriesService {
    getAll = () => axios.get(categoriesUrl);
}

export default new CategoriesService();