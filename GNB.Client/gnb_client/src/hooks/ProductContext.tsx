import {createContext} from 'react';
import { ProductModule, ProductProp } from "../modules/interfaces";

type RateContextProp = {
    productsState: ProductModule;
    getAllProducts: (id: string) => void;
    showFields: boolean;
}

export const ProductContext = createContext({} as RateContextProp);