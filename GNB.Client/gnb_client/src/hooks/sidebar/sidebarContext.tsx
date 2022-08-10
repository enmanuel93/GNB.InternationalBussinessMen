import {createContext} from 'react';

type SidebarProp = {
    setLoading: React.Dispatch<React.SetStateAction<boolean>>;
    loading: boolean;
}

export const sidebarContext = createContext({} as SidebarProp);