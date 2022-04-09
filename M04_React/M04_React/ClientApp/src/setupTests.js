const localStorageMock = {
  getItem: jest.fn(),
  setItem: jest.fn(),
  removeItem: jest.fn(),
  clear: jest.fn(),
};
global.localStorage = localStorageMock;

// Mock the request issued by the react app to get the client configuration parameters.
window.fetch = () => {
  return Promise.resolve(
    {
      ok: true,
      json: () => Promise.resolve({
        "authority": "https://localhost:7123",
        "client_id": "M04_React",
        "redirect_uri": "https://localhost:7123/authentication/login-callback",
        "post_logout_redirect_uri": "https://localhost:7123/authentication/logout-callback",
        "response_type": "id_token token",
        "scope": "M04_ReactAPI openid profile"
     })
    });
};
