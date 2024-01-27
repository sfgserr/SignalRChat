import api from "./oauth"

const getMesssages = () => {
  return api
    .get("/api/Message/Get");
};

const editMessage = (id, text) => {
  return api
    .get(`/api/Message/Edit?id=${id}&text=${text}`);
};

const sendMessage = (id, text) => {
  return api
    .post(`/api/Message/Send?id=${id}&text=${text}`, data);
};

const deleteMessage = (id) => {
  return api
    .delete(`/api/Message/Delete?id=${id}`);
};

export default {
  getMesssages,
  editMessage,
  sendMessage,
  deleteMessage
};