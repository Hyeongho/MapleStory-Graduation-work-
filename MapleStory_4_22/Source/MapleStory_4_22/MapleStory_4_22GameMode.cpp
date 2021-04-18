// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

#include "MapleStory_4_22GameMode.h"
#include "MapleStory_4_22Character.h"
#include "UObject/ConstructorHelpers.h"

AMapleStory_4_22GameMode::AMapleStory_4_22GameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPersonCPP/Blueprints/ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
