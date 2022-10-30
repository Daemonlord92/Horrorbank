import axios from "axios";
import { Dispatch } from "redux";
import { toast } from "react-toastify";
import IProfileCreationRequest from "../../interface/i-profile-creation-request";
import { Action, ActionType } from "./register-actions-types";

export const postNewUser = (profile: IProfileCreationRequest) => {
    return async (dispatch: Dispatch<Action>) => {
        dispatch({
            type: ActionType.POST_REGISTRATION_REQUEST
        });

        await axios({
            method: 'post',
            url: 'https://localhost:7069/api/User/profile',
            data: profile
        }).then(res => {
            dispatch({
                type: ActionType.POST_REGISTRATION_SUCCESS,
                payload:res.data
            });
            toast.success("Welcome to Horrorbank!")
        }).catch(err => {
            dispatch({
                type: ActionType.POST_REGISTRATION_FAILURE,
                payload: err.message
            });
            toast.error(err.message)
        });
    }
}