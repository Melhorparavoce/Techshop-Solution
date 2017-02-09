SELECT M.COD_MENU,E.COD_EXAME,E.DSC_EXAME,M.DSC_PARAMETRO1,M.DSC_PARAMETRO2,M.QTDE_PERGUNTAS FROM SER_MENU AS M
INNER JOIN SER_EXAME AS E 
ON M.COD_EXAME = E.COD_EXAME
INNER JOIN SER_TENTATIVA
WHERE IND_TIPO=2 AND E.COD_EXAME=1
ORDER BY E.DSC_EXAME,M.DSC_PARAMETRO1,M.DSC_PARAMETRO2
