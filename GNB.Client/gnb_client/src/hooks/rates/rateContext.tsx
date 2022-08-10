import {createContext} from 'react';
import { RateProp } from "../../modules/interfaces";

type RateContextProp = {
    ratesState: RateProp;
    getAllRates: () => void;
    showFields: boolean;
}

export const rateContext = createContext({} as RateContextProp);