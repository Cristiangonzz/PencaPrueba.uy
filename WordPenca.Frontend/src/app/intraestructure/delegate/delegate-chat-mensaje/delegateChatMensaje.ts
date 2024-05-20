import { CrearChatMensajeUseCase } from '../../../application/use-case/chat/crear-chatMensaje.use-case';
import { ChatMensajeService } from '../../../domain/services/ChatMensajeService';

const CrearChatMensajeUseCaseFactory = (() => {
  let instance: CrearChatMensajeUseCase;

  const factory = (service: ChatMensajeService): CrearChatMensajeUseCase => {
    if (!instance) {
      instance = new CrearChatMensajeUseCase(service);
    }

    return instance;
  };

  return factory;
})();

export const chatMensajeUseCaseProviders = {
  crearChatMensajeUseCaseProvider: {
    provide: CrearChatMensajeUseCase,
    useFactory: CrearChatMensajeUseCaseFactory,
    deps: [ChatMensajeService],
  },
};
