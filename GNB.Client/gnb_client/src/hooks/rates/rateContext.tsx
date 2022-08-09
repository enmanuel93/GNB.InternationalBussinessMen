import {createContext} from 'react';
import { RateProp } from "../../modules/interfaces";

type RateContextProp = {
    ratesState: RateProp;
    getAllRates: () => void
}

export const rateContext = createContext({} as RateContextProp);