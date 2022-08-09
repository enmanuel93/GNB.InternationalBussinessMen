import {createContext} from 'react';
import { RateModule, RateProp } from "../../modules/interfaces";

type RateContextProp = {
    rateSt: RateModule[];
    getAllRates: () => void
}

export const rateContext = createContext({} as RateContextProp);