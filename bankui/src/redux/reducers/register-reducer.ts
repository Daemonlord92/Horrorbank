import { number } from 'yup';
import IProfileCreationRequest from '../../interface/i-profile-creation-request';
import {
    Action,
    ActionType
} from '../actions/register-actions-types';

interface State {
    register: IProfileCreationRequest[],
    error: string | null
}

export const initialState = {
    register: [],
    error: null
};

export function registerReducer(state: State = initialState, action:Action):State {
    switch (action.type) {
        case ActionType.POST_REGISTRATION_REQUEST:
            return {
                ...state
            };
        case ActionType.POST_REGISTRATION_SUCCESS:
            return {
                ...state,
                register: action.payload
            };
        case ActionType.POST_REGISTRATION_FAILURE:
            return {
                ...state,
                error: action.payload
            };
        default:
            return state;
    }
}