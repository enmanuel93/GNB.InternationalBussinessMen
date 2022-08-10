import React, { useContext, useState } from "react";
import { Modal, Button } from "react-bootstrap";
import { modalMessageContext } from "../hooks/usefulContexts/modalMessageContext";

export default function ModalMessage(props: modalProps) {
  const{showModal, setModalMsg} = useContext(modalMessageContext);
  setModalMsg(props.show);

  return (
    <>
      <Modal show={showModal} onHide={() => setModalMsg(false)} animation={false}>
        <Modal.Header closeButton>
          <Modal.Title>{props.title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>{props.message}</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setModalMsg(false)}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

interface modalProps {
  title: string;
  message: string;
  show: boolean;
}
