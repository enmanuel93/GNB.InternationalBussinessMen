import React, {useReducer} from 'react';
import {rateContext} from './rateContext';
import RateReducer from './rateReducer';

import {GET_RATES} from '../../types/types';
import { axiosConnection } from '../../config/axiosConnection';

function RateState(prop: any) {
    const[state, dispatch] = RateReducer();

    const getAllRates = async () => {
        const resultado = await axiosConnection.get('/api/proyectos');

        try {
            dispatch({
                type: GET_RATES,
                payload: resultado.data
            });
        } catch (error) {
            console.log(error)
        }        
    }

    return (
        <rateContext.Provider value={{
            state: state,
            getAllRates: getAllRates
        }}>
            {prop.children}
        </rateContext.Provider>
    );
}

export default RateState;