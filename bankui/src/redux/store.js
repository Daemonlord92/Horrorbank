import { legacy_createStore, applyMiddleware } from "redux";
import thunk from 'redux-thunk';

import { registerReducer } from "./reducer/register-reducer";

export const store = legacy_createStore(
    registerReducer,
applyMiddleware(thunk));