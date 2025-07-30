import { useState } from 'react';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { login } from '../store/authSlice';
import { useNavigate } from 'react-router-dom';

export default function Login() {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const dispatch = useAppDispatch();
  const authStatus = useAppSelector(state => state.auth.status);
  const navigate = useNavigate();

  const handleLogin = async () => {
    await dispatch(login({ email, senha }));
    if (authStatus === 'authenticated') navigate('/produtos');
  };

  return (
    <div>
      <h1>Login</h1>
      <input type="text" value={email} onChange={e => setEmail(e.target.value)} />
      <input type="password" value={senha} onChange={e => setSenha(e.target.value)} />
      <button onClick={handleLogin}>Entrar</button>
    </div>
  );
}
