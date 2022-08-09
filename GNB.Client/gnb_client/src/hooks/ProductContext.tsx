import {createContext} from 'react';
import { RateModule, ProductProp } from "../modules/interfaces";

type RateContextProp = {
    productsState: ProductProp;
    getAllProducts: () => void
}

export const ProductContext = createContext({} as RateContextProp);