import { FaHome, FaExchangeAlt, FaMoneyBillAlt} from "react-icons/fa";
import {AiOutlineTransaction} from 'react-icons/ai';


export const RoutesConfig = [
  { path: "/", name: "Home", icon: <FaHome /> },
  {
    path: "/products",
    name: "Products",
    icon: <AiOutlineTransaction />,
  },
  {
    path: "/rates",
    name: "Rates",
    icon: <FaMoneyBillAlt />,
  },
  {
    path: "/transactions",
    name: "Transactions",
    icon: <FaExchangeAlt />,
  },
];
