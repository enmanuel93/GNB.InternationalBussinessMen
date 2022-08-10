import {createContext} from 'react';
import { RateModule, ProductProp } from "../modules/interfaces";

type RateContextProp = {
    productsState: ProductProp;
    getAllProducts: (id: string) => void
}

export const ProductContext = createContext({} as RateContextProp);