export const inputAnimation = {
  hidden: {
    width: 110,
    padding: 0,
  },
  show: {
    with: "140px",
    padding: "5px 10px",
    opacity: 1,
    transition: {
      duration: 0.2,
    },
  },
};

export const showAnimation = {
  hidden: {
    width: 0,
    opacity: 0,
    transition: {
      duration: 0.5,
    },
  },
  show: {
    with: "auto",
    opacity: 1,
    transition: {
      duration: 0.2,
    },
  },
};
