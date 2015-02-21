import sbt._
import sbt.Keys._
import play.Project._
import java.io.File

name := """WebPlay"""

version := "1.0-SNAPSHOT"

play.Project.playJavaSettings

scalacOptions ++= Seq("-encoding", "UTF-8")

resolvers += (
    "Local Maven Repository" at "file:///"+Path.userHome.absolutePath+"/.m2/repository"
)

libraryDependencies  ++= Seq(
      "ServiceClientProxy"     %  "ServiceClientProxy"             % "0.0.1-SNAPSHOT",
      "commons-beanutils"      %  "commons-beanutils"              % "1.8.3"
    )

// "ServiceClientProxy"     %  "ServiceClientProxy"             % "0.0.1-SNAPSHOT" withSources

//val WebPlay = play.Project(name, version, dependencies).settings(
//  scalacOptions ++= Seq("-encoding", "UTF-8")
//  // Add your own project settings here
//)

//
//lazy val WebPlay = (project in file("."))
//  .enablePlugins(PlayScala)
//  .aggregate(ServiceClientProxy)
//  .dependsOn(ServiceClientProxy)
//
//lazy val ServiceClientProxy = (project in file("modules/ServiceClientProxy"))