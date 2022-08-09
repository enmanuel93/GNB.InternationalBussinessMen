import {createContext} from 'react';
import { RateModule, ProductProp } from "../modules/interfaces";

type RateContextProp = {
    productSt: ProductProp;
    getAllProducts: () => void
}

export const ProductContext = createContext({} as RateContextProp);