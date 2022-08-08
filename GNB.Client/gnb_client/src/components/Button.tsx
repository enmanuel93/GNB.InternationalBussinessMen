import { ReactElement } from "react";

export default function Button(props: buttonProps) {
  return (
    <button
      type={props.type}
      disabled={props.disabled}
      onClick={props.onClick}
      className={props.className}
    >
      {props.children}
    </button>
  );
}

interface buttonProps {
  children: string;
  onClick?(): void;
  type: "button" | "submit";
  disabled: boolean;
  className: string;
}

Button.defaultProps = {
  type: "button",
  disabled: false,
  className: "btn btn-primary",
};