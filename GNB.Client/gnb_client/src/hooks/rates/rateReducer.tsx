import { useReducer } from 'react';
import {GET_RATES} from '../../types/types';


const initialState = {
    rates: []
}

type ActionType = {
    type: 'GET_RATES',
    payload: []
};

const rtReducer = (state: typeof initialState, action: ActionType) => {
    switch(action.type){
        case GET_RATES:
            return state;
        default:
            return state;
    }
}

const RateReducer = () =>  {
   return useReducer(rtReducer, initialState);
}

export default RateReducer;