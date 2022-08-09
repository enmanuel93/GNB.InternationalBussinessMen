import {createContext} from 'react';
import { RateModule, RateProp } from "../../modules/interfaces";

type RateContextProp = {
    rates: RateProp;
    getAllRates: () => void
}

export const rateContext = createContext({} as RateContextProp);