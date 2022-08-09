import {createContext} from 'react';

interface propRate {
    from: string;
    to: string;
    rate: number
}

export const rateContext = createContext({
    rate: propRate,
    getAllRates: () => void
});