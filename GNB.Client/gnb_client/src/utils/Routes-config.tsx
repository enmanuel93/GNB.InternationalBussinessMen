import { BiCog } from "react-icons/bi";
import { FaHome, FaUser } from "react-icons/fa";


export const RoutesConfig = [
  { path: "/", name: "Home", icon: <FaHome /> },
  {
    path: "/products",
    name: "Products",
    icon: <FaUser />,
  },
  {
    path: "/rates",
    name: "Rates",
    icon: <BiCog />,
  },
  {
    path: "/transactions",
    name: "Transactions",
    icon: <BiCog />,
  },
];
