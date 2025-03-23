import { ReactNode } from "react";

interface ModalProps {
    isOpen: boolean;
    closeModal: () => void;
    children: ReactNode;
}

const Modal = ({ isOpen, closeModal, children }: ModalProps) => {
    if (!isOpen) return null;

    return (
        <div className="modal is-active">
            <div className="modal-background" onClick={closeModal}></div>
            <div className="modal-content">
                <div className="box">{children}</div>
            </div>
            <button className="modal-close is-large" aria-label="close" onClick={closeModal}></button>
        </div>
    );
};

export default Modal;
