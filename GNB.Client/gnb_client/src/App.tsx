import "./App.css";
import "./styles/loading.css";
import React, { useEffect, useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Sidebar from "./components/Sidebar";
import Home from "./pages/Home";
import Products from "./pages/Products";
import Transactions from "./pages/Transactions";
import Rates from "./pages/Rates";
import RateState from "./hooks/rates/rateState";
import TransactionState from "./hooks/transactions/transactionState";
import ProductState from "./hooks/productState";
import { sidebarContext } from "./hooks/sidebar/sidebarContext";
import { modalMessageContext } from "./hooks/usefulContexts/modalMessageContext";

function App() {
  const [loading, setLoading] = useState<boolean>(false);
  const [showModal, setModalMsg] = useState<boolean>(false);

  return (
    <>
      <sidebarContext.Provider
        value={{
          setLoading: setLoading,
          loading: loading,
        }}
      >
        <modalMessageContext.Provider
          value={{ setModalMsg: setModalMsg, showModal: showModal }}
        >
          <ProductState>
            <TransactionState>
              <RateState>
                <Router>
                  <Sidebar>
                    <Routes>
                      <Route path="/" element={<Home />} />
                      <Route path="/products" element={<Products />} />
                      <Route path="/rates" element={<Rates />} />
                      <Route path="/transactions" element={<Transactions />} />
                    </Routes>
                  </Sidebar>
                </Router>
              </RateState>
            </TransactionState>
          </ProductState>
        </modalMessageContext.Provider>
      </sidebarContext.Provider>
    </>
  );
}

export default App;
