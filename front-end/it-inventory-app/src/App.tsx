import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './pages/Login';
import Produtos from './pages/Produtos';

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/produtos" element={<Produtos />} />
      </Routes>
    </BrowserRouter>
  );
}
