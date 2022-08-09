import React, {useReducer} from 'react';
import {transactionContext} from './transactionContext';

import {GET_TRANSACTIONS} from '../../types/types';

function productState(prop: any) {

    //const[state, dispatch] = useReducer();

    return (
        <transactionContext.Provider value={{}}>
            {prop.children}
        </transactionContext.Provider>
    );
}

export default productState;