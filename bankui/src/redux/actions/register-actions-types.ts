import axios from "axios";
import { type } from "os";
import { AnyAction } from "redux";
import IProfileCreationRequest from "../../interface/i-profile-creation-request";

export enum ActionType {
    POST_REGISTRATION_REQUEST = "POST_REGISTRATION_REQUEST",
    POST_REGISTRATION_SUCCESS = "POST_REGISTRATION_SUCCESS",
    POST_REGISTRATION_FAILURE = "POST_REGISTRATION_FAILURE"
}

interface registerRequest {
    type: ActionType.POST_REGISTRATION_REQUEST;
}

interface registerSuccess {
    type: ActionType.POST_REGISTRATION_SUCCESS;
    payload: IProfileCreationRequest[];
}

interface registerFailed {
    type: ActionType.POST_REGISTRATION_FAILURE;
    payload: string;
}

export type Action = registerRequest | registerSuccess | registerFailed;

// export const postNewUser = (data: IProfileCreationRequest) => (dispatch:AnyAction) => {
//     dispatch({type: POST_REGISTRATION_REQUEST});
//     axios({
//         method: 'post',
//         url: 'https://localhost:7069/api/User/profile',
//         data: data
//     }).then(res => {
//         dispatch({ type: POST_REGISTRATION_SUCCESS, payload: res});
//         alert(res);
//     }).catch(err => {
//         dispatch({ type: POST_REGISTRATION_FAILURE, payload: err});
//         alert(err);
//     })
// }