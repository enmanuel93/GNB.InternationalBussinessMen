import React from "react";

export default function CustomInput(props: InputProps) {
  return (
    <div className={props.className}>
      <input
        type="text"
        className={`form-control ${props.className}`}
        onChange={props.onChange}
        name={props.name}
        placeholder={props.placeHolder}
        required
      />
      <div className="invalid-feedback">Please provide a valid city.</div>
    </div>
  );
}

interface InputProps {
  className: string;
  placeHolder?: string;
  name: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void 
}
