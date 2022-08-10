import React, { useState, useEffect, useContext } from "react";
import { AnimatePresence, motion } from "framer-motion";
import { FaBars } from "react-icons/fa";
import { BiSearch } from "react-icons/bi";
import { NavLink } from "react-router-dom";
import { RoutesConfig } from "../utils/Routes-config";
import { inputAnimation, showAnimation } from "../types/animation-config";
import { sidebarContext } from "../hooks/sidebar/sidebarContext";

type PropSidebar = {
  children: any;
};

const Sidebar = ({ children }: PropSidebar) => {
  const [isOpen, setIsOpen] = useState<boolean>(false);
  const{loading, setLoading} = useContext(sidebarContext);

  const toggle = () => setIsOpen(!isOpen);

  useEffect(() => {
    setLoading(true);
    setTimeout(() => {
      setLoading(false);
    }, 1000);
  }, []);

  return (
    <div className="main-container">
      {loading ? (
        <div className="loader-container">
          <div className="spinner"></div>
        </div>
      ) : (
        <>
          <motion.div
            animate={{
              width: isOpen ? "200px" : "45px",
              transition: {
                duration: 0.5,
                type: "spring",
                damping: 10,
              },
            }}
            className="sidebar"
          >
            <div className="top_section">
              {isOpen && (
                <motion.h1
                  variants={showAnimation}
                  initial="hidden"
                  animate="show"
                  exit="hidden"
                  className="logo"
                >
                  GNB
                </motion.h1>
              )}
              <div className="bars">
                <FaBars onClick={toggle} />
              </div>
            </div>
            <br />
            <section className="routes">
              {RoutesConfig.map((route) => (
                <NavLink to={route.path} key={route.name} className="link">
                  <div className="icon">{route.icon}</div>
                  <AnimatePresence>
                    {isOpen && (
                      <motion.div
                        variants={showAnimation}
                        initial="hidden"
                        animate="show"
                        exit="hidden"
                        className="link_text"
                      >
                        {route.name}
                      </motion.div>
                    )}
                  </AnimatePresence>
                </NavLink>
              ))}
            </section>
          </motion.div>
          <main>{children}</main>
        </>
      )}
    </div>
  );
};

export default Sidebar;
