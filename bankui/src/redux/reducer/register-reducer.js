import {
    POST_NEW_USER_REQUEST,
    POST_NEW_USER_SUCCESS,
    POST_NEW_USER_FAILED
} from '../actions/register-actions';

export const initialState = {
    register: [],
    error: null
}

export function registerReducer(state = initialState, action) {
    switch(action.type){
        case POST_NEW_USER_REQUEST:
            return {
                ...state
            }
        
        case POST_NEW_USER_SUCCESS:
            return {
                ...state,
                register: action.payload
            }
        
        case POST_NEW_USER_FAILED:
            return {
                ...state,
                error: action.payload
            }
        
        default:
            return state
    }
}