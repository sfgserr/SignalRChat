import api from "./oauth"

const findUsers = (name) => {
  return api
    .get(`/api/Search/FindUsersByName?name=${name}`);
};

export default {
    findUsers,
};