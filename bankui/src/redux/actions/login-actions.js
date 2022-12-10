import axios from 'axios';

export const POST_LOGIN_REQUEST = "POST_LOGIN_REQUEST";
export const POST_LOGIN_SUCCESS = "POST_LOGIN_SUCCESS";
export const POST_LOGIN_FAILURE = "POST_LOGIN_FAILURE";

export const postLogin = data => dispatch => {
    dispatch({ type: POST_LOGIN_REQUEST });
    axios({
        method: 'post',
        url: 'https://localhost:7069/api/Token/login',
        data: data
    }).then(res => {
        dispatch({ type: POST_LOGIN_SUCCESS, payload: res});
        console.log("login-actions:15:then statement:", res.data);
        sessionStorage.setItem("Authorization", res.data);
    }).catch(error => {
        dispatch({ type: POST_LOGIN_FAILURE, payload: error.response });
        console.log(error.response);
    })
}