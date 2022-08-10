import {createContext} from 'react';

type SidebarProp = {
    setModalMsg: React.Dispatch<React.SetStateAction<boolean>>;
    showModal: boolean;
}

export const modalMessageContext = createContext({} as SidebarProp);