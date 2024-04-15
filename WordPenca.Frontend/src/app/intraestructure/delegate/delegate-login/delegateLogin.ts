import { GetAllMatchUseCase } from "../../../application/use-case/match/get-all-equipo.use-case";
import { MatchService } from "../../../domain/services/MatchService ";



const GetAllMatchUseCaseFactory = (() => {
  let instance: GetAllMatchUseCase;

  const factory = (service: MatchService): GetAllMatchUseCase => {
    if (!instance) {
      instance = new GetAllMatchUseCase(service);
    }

    return instance;
  };

  return factory;
})();


export const matchUseCaseProviders = {

  getAllmatchUseCaseProvider: {
    provide: GetAllMatchUseCase,
    useFactory: GetAllMatchUseCaseFactory,
    deps: [MatchService],
  },

};
