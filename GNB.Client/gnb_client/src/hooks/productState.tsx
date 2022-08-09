import React, {useReducer} from 'react';
import {ProductContext} from '../hooks/ProductContext';

import {CALCULATE_PRODUCTS} from '../types/types';

function productState(prop: any) {

    //const[state, dispatch] = useReducer();

    return (
        <ProductContext.Provider value={{}}>
            {prop.children}
        </ProductContext.Provider>
    );
}

export default productState;