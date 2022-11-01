import axios from 'axios';

export const POST_NEW_USER_REQUEST  = "POST_NEW_USER_REQUEST";
export const POST_NEW_USER_SUCCESS  = "POST_NEW_USER_SUCCESS";
export const POST_NEW_USER_FAILED   = "POST_NEW_USER_FAILED";

export const postNewUser = data => dispatch => {
    dispatch({ type: POST_NEW_USER_REQUEST });
    axios({
        method: 'post',
        url: 'https://localhost:7069/api/User/profile',
        data: data
    }).then(res => {
        dispatch({ type: POST_NEW_USER_SUCCESS, payload: res });
        console.log(res);
    }).catch(error => {
        dispatch({ type: POST_NEW_USER_FAILED, payload: error.response });
        console.log(error.response);
    })
}
