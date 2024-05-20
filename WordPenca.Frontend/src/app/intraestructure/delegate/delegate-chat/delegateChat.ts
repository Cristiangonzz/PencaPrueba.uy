import { CrearChatUseCase } from '../../../application/use-case/chat/crear-chat.use-case';
import { GetChatUseCase } from '../../../application/use-case/chat/get-chat.use-case';
import { GetChatHistorialUseCase } from '../../../application/use-case/chat/get-chatHistorial.use-case';
import { GetChatUsuarioUseCase } from '../../../application/use-case/chat/get-chatUsuario.use-case';
import { GetAllChatUseCase } from '../../../application/use-case/chat/getAll-chats.use-case';
import { ChatService } from '../../../domain/services/ChatService';
import { GetAllChatUsuariosUseCase } from '../../../application/use-case/chat/getAll-chat-usuarios.use-case';

const GetAllChatUseCaseFactory = (() => {
  let instance: GetAllChatUseCase;

  const factory = (service: ChatService): GetAllChatUseCase => {
    if (!instance) {
      instance = new GetAllChatUseCase(service);
    }

    return instance;
  };

  return factory;
})();

const CrearChatUseCaseFactory = (() => {
  let instance: CrearChatUseCase;

  const factory = (service: ChatService): CrearChatUseCase => {
    if (!instance) {
      instance = new CrearChatUseCase(service);
    }

    return instance;
  };

  return factory;
})();



const GetChatUseCaseFactory = (() => {
  let instance: GetChatUseCase;

  const factory = (service: ChatService): GetChatUseCase => {
    if (!instance) {
      instance = new GetChatUseCase(service);
    }

    return instance;
  };

  return factory;
})();

const GetChatHistorialUseCaseFactory = (() => {
  let instance: GetChatHistorialUseCase;

  const factory = (service: ChatService): GetChatHistorialUseCase => {
    if (!instance) {
      instance = new GetChatHistorialUseCase(service);
    }

    return instance;
  };

  return factory;
})();

const GetChatUsuarioUseCaseFactory = (() => {
  let instance: GetChatUsuarioUseCase;

  const factory = (service: ChatService): GetChatUsuarioUseCase => {
    if (!instance) {
      instance = new GetChatUsuarioUseCase(service);
    }

    return instance;
  };

  return factory;
})();
const GetChatAllUsuarioUseCaseFactory = (() => {
  let instance: GetAllChatUsuariosUseCase;

  const factory = (service: ChatService): GetAllChatUsuariosUseCase => {
    if (!instance) {
      instance = new GetAllChatUsuariosUseCase(service);
    }

    return instance;
  };

  return factory;
})();

export const chatUseCaseProviders = {
  getAllChatUsuariosUseCaseProvider: {
    provide: GetAllChatUsuariosUseCase,
    useFactory: GetChatAllUsuarioUseCaseFactory,
    deps: [ChatService],
  },

  getChatUsuarioUseCaseProvider: {
    provide: GetChatUsuarioUseCase,
    useFactory: GetChatUsuarioUseCaseFactory,
    deps: [ChatService],
  },
  getChatHistorialUseCaseProvider: {
    provide: GetChatHistorialUseCase,
    useFactory: GetChatHistorialUseCaseFactory,
    deps: [ChatService],
  },
  getChatUseCaseProvider: {
    provide: GetChatUseCase,
    useFactory: GetChatUseCaseFactory,
    deps: [ChatService],
  },

  crearChatUseCaseProvider: {
    provide: CrearChatUseCase,
    useFactory: CrearChatUseCaseFactory,
    deps: [ChatService],
  },

  getAllChatUseCaseProvider: {
    provide: GetAllChatUseCase,
    useFactory: GetAllChatUseCaseFactory,
    deps: [ChatService],
  },
};
