import axios from 'axios';

class AuthService {
    url = 'http://localhost:59028/';

    register = user => axios.post(this.url + 'api/account/register', user);

    logIn = (email, password) => 
        axios.post(
            this.url + 'token', 
            this.JSON_to_URLEncoded({
                'grant_type': 'password',
                'username': email,
                'password': password
            }),
            {
                'Content-Type': 'application/x-www-form-urlencoded'
            }); 

    getToken = () => {
        return localStorage.getItem('token');
    }

    setToken = token => {
        localStorage.setItem('token', token);
    }

    JSON_to_URLEncoded(element,key,list){
        var list = list || [];
        if(typeof(element)=='object'){
          for (var idx in element)
            this.JSON_to_URLEncoded(element[idx],key?key+'['+idx+']':idx,list);
        } else {
          list.push(key+'='+encodeURIComponent(element));
        }
        return list.join('&');
      }
}

export default new AuthService();