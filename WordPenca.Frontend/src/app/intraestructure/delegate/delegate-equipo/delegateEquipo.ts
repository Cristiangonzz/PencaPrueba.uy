import { CreateEquipoUseCase } from "../../../application/use-case/create-equipo.use-case";
import { GetAllEquipoUseCase } from "../../../application/use-case/get-all-equipo.use-case";
import { EquipoService } from "../../../domain/services/EquipoService";



const GetAllEquipoUseCaseFactory = (() => {
  let instance: GetAllEquipoUseCase;

  const factory = (service: EquipoService): GetAllEquipoUseCase => {
    if (!instance) {
      instance = new GetAllEquipoUseCase(service);
    }

    return instance;
  };

  return factory;
})();

const CreateEquipoUseCaseFactory = (() => {
  let instance: CreateEquipoUseCase;

  const factory = (service: EquipoService): CreateEquipoUseCase => {
    if (!instance) {
      instance = new CreateEquipoUseCase(service);
    }

    return instance;
  };

  return factory;
})();

export const equipoUseCaseProviders = {

  getAllEquipoUseCaseProvider: {
    provide: GetAllEquipoUseCase,
    useFactory: GetAllEquipoUseCaseFactory,
    deps: [EquipoService],
  },

  createEquipoUseCaseProvider: {
    provide: CreateEquipoUseCase,
    useFactory: CreateEquipoUseCaseFactory,
    deps: [EquipoService],
  },

};
